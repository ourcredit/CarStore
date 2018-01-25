<template>
  <div class="animated fadeIn">
    <Row>
      <milk-table ref="list" :layout="[5,17,2]" :columns="cols" :search-api="searchApi" :params="params">
        <template slot="search">
          <Form ref="params" :model="params" inline :label-width="60">
            <FormItem label="标题名称">
              <Input v-model="params.filter" placeholder="标题名称"></Input>
            </FormItem>
          </Form>
        </template>
        <template slot="actions">
          <Button @click="add" type="primary">添加</Button>
        </template>
      </milk-table>
    </Row>
    <!-- 添加和编辑窗口 -->
    <Modal :width="800" :transfer="false" v-model="isshow" title="文档编辑" :mask-closable="false" @on-ok="save" @on-cancel="cancel">
      <Row>
        <Col span="8">文章标题</Col>
        <Input v-model="model.title" placeholder="请输入标题" style="width: 300px"></Input>
        <Col span="16"></Col>
      </Row>
      <Row>
      </Row>
    </Modal>
  </div>
</template>

<script>
import {
  getAdsences,
  getAdsenceEdit,
  modifyAdsence,
  deleteAdsence,
  publicAdsences
} from "api/adsence";
import axios from "axios";
export default {
  name: "account",
  data() {
    return {
      cols: [
        {
          title: "仓库名称",
          key: "title"
        },
        {
          title: "仓库编号",
          key: "title"
        },
        {
          title: "区域",
          key: "title"
        },
        {
          title: "商品",
          key: "title"
        },
        {
          title: "剩余数量",
          key: "title"
        },
        {
          title: "待补数量",
          key: "title"
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
              "补货"
            );
            divs.push(del);

            return h("div", divs);
          }
        }
      ],
      model: {},
      isshow: false,
      searchApi: getAdsences,
      params: {
        filter: ""
      }
    };
  },
  components: {},
  created() {},
  destroyed() {},
  methods: {
    save() {
      var table = this.$refs.list;
      modifyAdsence({ adsenceEditDto: this.model }).then(c => {
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
      publicAdsences({ id: row.id }).then(c => {
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
          deleteAdsence(parms).then(c => {
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
      getAdsenceEdit({
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