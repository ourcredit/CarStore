<template>
  <div class="animated fadeIn">
    <Row>
      <milk-table ref="list" :layout="[18,2,2]" :columns="cols" :search-api="searchApi" :params="params">
        <template slot="search">
          <Form ref="params" :model="params" inline :label-width="60">
            <FormItem label="仓库名称">
              <Input v-model="params.name" placeholder="仓库名称"></Input>
            </FormItem>
            <FormItem label="仓库编号">
              <Input v-model="params.num" placeholder="仓库编号"></Input>
            </FormItem>
            <FormItem label="区域名">
              <Input v-model="params.area" placeholder="区域名"></Input>
            </FormItem>
          </Form>
        </template>
      </milk-table>
    </Row>
    <!-- 添加和编辑窗口 -->
    <Modal :loading="true" :width="800" :transfer="false" v-model="isshow" title="仓库编辑" :mask-closable="false"
     @on-ok="save" @on-cancel="cancel">
       <Row>
            <milk-table ref="list" :layout="[8]" :columns="ucols" :search-api="usearchApi" :params="uparams">
                  <template slot="search">
                    <Form ref="params" :model="uparams" inline :label-width="60">
                        <FormItem label="用户姓名">
                            <Input v-model="uparams.name" placeholder="请输入用户姓名"></Input>
                        </FormItem>
                    </Form>
                </template>
            </milk-table>
        </Row>
    </Modal>
  </div>
</template>

<script>
import {
  getHouses,
  getHouseEdit,
  getHouse,
  modifyHouse,
  deleteHouse,
  deleteHouses,
  exportHouse,
  changehouseuser
} from "api/house";
import { getAllAreas } from "api/area";
import { getUsers } from "api/manage";
import axios from "axios";
export default {
  name: "house",
  data() {
    return {
      cols: [
        {
          title: "仓库名称",
          key: "wareName"
        },
        {
          title: "仓库编号",
          key: "wareNum"
        },
        {
          title: "区域",
          key: "areaName"
        },
        {
          title: "创建时间",
          key: "creationTime",
          render: (h, params) => {
            return this.$fmtTime(params.row.creationTime);
          }
        },
        {
          title: "负责人",
          key: "action",
          align: "center",
          render: (h, params) => {
            var divs = [];
            var name =
              params.row.chargeUserName != null
                ? params.row.chargeUserName
                : "选择负责人";
            var del = h(
              "Button",
              {
                props: {
                  type: "error",
                  size: "small"
                },
                style: {
                  marginRight: "5px"
                },
                on: {
                  click: () => {
                    this.choose(params.row);
                  }
                }
              },
              name
            );
            divs.push(del);

            return h("div", divs);
          }
        }
      ],
      model: {},
      isshow: false,
      searchApi: getHouses,
      usearchApi: getUsers,
      params: {
        name: "",
        num: "",
        area: ""
      },
      uparams: {
        name: ""
      },
      ucols: [
        {
          title: "用户姓名",
          key: "name"
        },
        {
          title: "联系方式",
          key: "phoneNumber"
        }
      ]
    };
  },
  components: {},
  created() {},
  destroyed() {},
  methods: {
    save() {
      var table = this.$refs.list;
      if (!table.current || !table.current.id) {
        this.$Message.warning("请选择负责人");
        return;
      }
      changehouseuser({
        houseId: this.model.id,
        userId: table.current.id
      }).then(c => {
        if (c.success) {
          this.isshow = false;
          table.initData();
        }
      });
    },
    choose(row) {
      this.model = row;
      this.isshow = true;
    },
    cancel() {
      this.isshow = false;
      this.model = {};
    }
  }
};
</script>

<style type="text/css" scoped>

</style>