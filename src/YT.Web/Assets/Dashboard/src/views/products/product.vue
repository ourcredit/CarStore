<template>
    <div class="animated fadeIn">
        <Row>
            <milk-table ref="list" :layout="[18,2,2]" :columns="cols" :search-api="searchApi" :params="params">
                <template slot="search">
                    <Form ref="params" :model="params" inline :label-width="60">
                        <FormItem label="商品名">
                            <Input v-model="params.name" placeholder="商品名"></Input>
                        </FormItem>
                        <FormItem label="商品编号">
                            <Input v-model="params.num" placeholder="商品编号"></Input>
                        </FormItem>
                    </Form>
                </template>
                <template slot="actions">
                    <Button @click="add" type="primary">添加</Button>
                </template>
            </milk-table>
        </Row>
        <!-- 添加和编辑窗口 -->
        <Modal :loading="true" :width="800" :transfer="false" v-model="isshow" title="商品编辑" :mask-closable="false" @on-ok="save"
            @on-cancel="cancel">
            <Form inline :model="model" :label-width="80">
                <Upload multiple type='drag' :on-error='error' :on-success='success' :headers='upload.headers' :action='upload.url'>
                    <div style='padding: 20px 0'>
                        <Icon type='ios-cloud-upload' size='52' style='color: #3399ff'></Icon>
                        <p>点击或将文件拖拽到这里上传</p>
                    </div>
                </Upload>
                <FormItem label="商品名">
                    <Input v-model="model.productName" placeholder="商品名"></Input>
                </FormItem>
                <FormItem label="商品编号">
                    <Input v-model="model.productNum" placeholder="商品编号"></Input>
                </FormItem>

                <FormItem label="默认价格">
                    <InputNumber :min="1" v-model="model.price"></InputNumber>
                </FormItem>
                <FormItem label="成本价格">
                    <InputNumber :min="1" v-model="model.cost"></InputNumber>
                </FormItem>
                <FormItem label="描述">
                    <Input v-model="model.description" type="textarea" :autosize="{minRows: 2,maxRows: 5}" placeholder="描述"></Input>
                </FormItem>
            </Form>
        </Modal>
    </div>
</template>

<script>
import {
  getProducts,
  getProductEdit,
  getProduct,
  modifyProduct,
  deleteProduct,
  deleteProducts,
  exportProduct
} from "api/product";
import axios from "axios";
export default {
  name: "Product",
  data() {
    return {
      cols: [
        {
          title: "商品名",
          key: "productName"
        },
        {
          title: "商品编号",
          key: "productNum"
        },
        {
          title: "商品描述",
          key: "description"
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
      searchApi: getProducts,
      params: {
        name: "",
        num: ""
      },
      upload: {
        url: "https://dingding.leftins.com/api/File/ImageUpload",
        headers: {
          Authorization: "Bearer " + this.$store.getters.token
        }
      }
    };
  },
  components: {},
  created() {},
  destroyed() {},
  methods: {
    save() {
      var table = this.$refs.list;
      modifyProduct({
        productEditDto: this.model
      }).then(c => {
        if (c.success) {
          this.isshow = false;
          table.initData();
        }
      });
    },
    add() {
      this.getInfo(null);
      this.isshow = true;
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
          deleteProduct(parms).then(c => {
            if (c.success) {
              table.initData();
            }
          });
        }
      });
    },
    getInfo(id) {
      getProductEdit({
        id: id
      }).then(r => {
        if (r.success && r.result) {
          this.model = r.result.product;
        }
      });
    },
    error(error, file, filelist) {
      if (!file.success) {
        this.$Message.error(file.error.message);
      }
    },
    success(response, file, filelist) {
      if (response.success) {
        this.model.profileId = response.result[0].guid;
      }
    }
  }
};
</script>

<style type="text/css" scoped>

</style>