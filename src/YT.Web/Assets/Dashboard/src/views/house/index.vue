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
        <template slot="actions">
          <Button @click="add" type="primary">添加</Button>
        </template>
      </milk-table>
    </Row>
    <!-- 添加和编辑窗口 -->
    <Modal :loading="true" :width="800" :transfer="false" v-model="isshow" title="仓库编辑" :mask-closable="false"
     @on-ok="save" @on-cancel="cancel">
      <Form :model="model" :label-width="80">
        <FormItem label="仓库名称">
            <Input v-model="model.wareName" placeholder="仓库名称"></Input>
        </FormItem>
          <FormItem label="仓库编号">
            <Input v-model="model.wareNum" placeholder="仓库编号"></Input>
        </FormItem>
        <FormItem label="分类">
           <Tree ref="tree" :data="areas" @on-select-change="select"></Tree>
        </FormItem>
        <FormItem label="描述">
            <Input v-model="model.description" type="textarea"
             :autosize="{minRows: 2,maxRows: 5}"
              placeholder="描述"></Input>
        </FormItem>
     
    </Form>
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
  exportHouse
} from "api/house";
import { getAllAreas } from "api/area";
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
          title: "操作",
          key: "action",
          align: "center",
          render: (h, params) => {
            var divs = [];
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
                    this.delete(params.row);
                  }
                }
              },
              "删除"
            );
            divs.push(del);
            if (!params.row.isActive) {
              divs.push(
                h(
                  "Button",
                  {
                    props: {
                      type: "primary",
                      size: "small"
                    },
                    style: {
                      marginRight: "5px"
                    },
                    on: {
                      click: () => {
                        this.edit(params.row);
                      }
                    }
                  },
                  "编辑"
                )
              );
            }
            return h("div", divs);
          }
        }
      ],
      model: {},
      isshow: false,
      searchApi: getHouses,
      params: {
        name: "",
        num: "",
        area: ""
      },
      areas: [],
      selectModal: null
    };
  },
  components: {},
  created() {},
  destroyed() {},
  methods: {
    save() {
      var table = this.$refs.list;
      if (this.selectModal == null) {
        console.log(this.$Message);
        this.$Message.info("请选择区域节点");
        return;
      }
      this.model.areaId = this.selectModal.id;
      modifyHouse({
        wareHouseEditDto: this.model
      }).then(c => {
        if (c.success) {
          this.isshow = false;
          table.initData();
        }
      });
    },
    select(arr) {
      this.selectModal = arr[0];
    },
    add() {
      this.getInfo(null);
      getAllAreas().then(r => {
        if (r.success) {
          this.areas = this.$genderTree(r.result, null, "parentId");
        }
      });
      this.isshow = true;
    },
    public(row) {
      publicAdsences;
      var table = this.$refs.list;
      publicAdsences({
        id: row.id
      }).then(c => {
        if (c.success) {
          table.initData();
        }
      });
    },
    edit(row) {
      this.getInfo(row.id);
      this.isshow = true;
    },
    cancel() {
      this.isshow = false;
      this.model = {};
    },
    // 删除
    delete(model) {
      var table = this.$refs.list;
      this.$Modal.confirm({
        title: "删除提示",
        content: "确定要删除么?",
        onOk: () => {
          const parms = {
            id: model.id
          };
          deleteHouse(parms).then(c => {
            if (c.success) {
              table.initData();
            }
          });
        }
      });
    },
    getInfo(id) {
      getHouseEdit({
        id: id
      }).then(r => {
        if (r.success && r.result) {
          this.model = r.result.wareHouse;
        }
      });
    }
  }
};
</script>

<style type="text/css" scoped>

</style>