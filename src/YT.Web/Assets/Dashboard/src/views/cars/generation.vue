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
    <Modal :width="800" :transfer="false" v-model="isshow" title="仓库编辑" :mask-closable="false"
     @on-ok="save" @on-cancel="cancel">
      <Form :model="model" :label-width="80">
        <FormItem label="仓库名称">
            <Input v-model="model.houseName" placeholder="仓库名称"></Input>
        </FormItem>
          <FormItem label="仓库编号">
            <Input v-model="model.houseNum" placeholder="仓库编号"></Input>
        </FormItem>
        <FormItem label="分类">
            <Select v-model="model.areaId">
                <Option value="beijing">New York</Option>
                <Option value="shanghai">London</Option>
                <Option value="shenzhen">Sydney</Option>
            </Select>
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
import axios from "axios";
export default {
  name: "account",
  data() {
    return {
      cols: [
        {
          title: "车牌号",
          key: "wareNum"
        },
        {
          title: "司机电话",
          key: "areaName"
        },
        {
          title: "区域",
          key: "areaName"
        },
        {
          title: "代理商",
          key: "creationTime"
        },
        {
          title: "提交日期",
          key: "creationTime"
        },

        {
          title: "账户余额",
          key: "creationTime"
        },
        {
          title: "提现金额",
          key: "creationTime"
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
              "通过"
            );
            divs.push(del);
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
                "拒绝"
              )
            );

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
      }
    };
  },
  components: {},
  created() {},
  destroyed() {},
  methods: {
    save() {
      var table = this.$refs.list;
      modifyHouse({
        adsenceEditDto: this.model
      }).then(c => {
        if (c.success) {
          table.initData();
        }
      });
    },
    add() {
      this.getInfo(null);
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
    handleImageAdded(file, Editor, cursorLocation) {
      const CLIENT_ID = "993793b1d8d3e2e";
      var formData = new FormData();
      formData.append("image", file);
      axios({
        url: "http://192.168.0.202:8888/api/file/imageupload",
        method: "POST",
        headers: {
          Authorization: "Client-ID " + CLIENT_ID
        },
        data: formData
      })
        .then(result => {
          result.result.forEach(element => {
            Editor.insertEmbed(cursorLocation, "image", element.viewUrl);
          });
        })
        .catch(err => {
          this.$Message.error(err.message);
        });
    },
    getInfo(id) {
      getHouse({
        id: id
      }).then(r => {
        if (r.success && r.result) {
          this.model = r.result.adsence;
        }
      });
    }
  }
};
</script>

<style type="text/css" scoped>

</style>