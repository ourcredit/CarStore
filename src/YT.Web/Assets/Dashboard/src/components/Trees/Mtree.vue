<template>
<Row>
  <Row>
      <Col span="8"  offset="6">
    <Button @click="parentAdd">添加根节点</Button>
  </Col>
  </Row>
  <Col span="8">
    <Tree :data="list" :render="renderContent"></Tree>
  </Col>
   <!-- 添加和编辑窗口 -->
    <Modal :width="400" :transfer="false" v-model="isshow" title="添加区域" :mask-closable="false"
     @on-ok="save"
     @on-cancel="cancel">
      <Form :model="model" :label-width="80">
        <FormItem label="上级名称">
          <Input  v-model="model.parentName" placeholder="上级名称"></Input>
        </FormItem>
        <FormItem label="区域名">
          <Input v-model="model.areaName" placeholder="区域名"></Input>
        </FormItem>
      </Form>
    </Modal>
</Row>

</template>
<script>
import {
  getAllAreas,
  getAreaEdit,
  getArea,
  modifyArea,
  deleteArea
} from "api/area";

export default {
  name: "mtree",
  props: {
    //表格头字段
    current: {
      type: Number,
      required: false,
      default: null
    }
  },
  data() {
    return {
      list: [],
      isshow: false,
      model: { parentName: "" },
      buttonProps: {
        type: "ghost",
        size: "small"
      }
    };
  },
  created() {
    this.init();
  },
  methods: {
    init() {
      getAllAreas().then(r => {
        this.list = this.$genderTree(r.result, null, "parentId", this.current);
      });
    },
    renderContent(h, { root, node, data }) {
      return h(
        "span",
        {
          style: {
            display: "inline-block",
            width: "100%"
          }
        },
        [
          h("span", [
            h("Icon", {
              props: {
                type: "ios-paper-outline"
              },
              style: {
                marginRight: "8px"
              }
            }),
            h("span", data.title)
          ]),

          h(
            "span",
            {
              style: {
                display: "inline-block",
                float: "right",
                marginRight: "32px"
              }
            },
            [
              h("Button", {
                props: Object.assign({}, this.buttonProps, {
                  icon: "ios-plus-empty"
                }),
                style: {
                  marginRight: "8px"
                },
                on: {
                  click: () => {
                    this.create(data);
                  }
                }
              }),
              h("Button", {
                props: Object.assign({}, this.buttonProps, {
                  icon: "ios-minus-empty"
                }),
                on: {
                  click: () => {
                    this.remove(root, node, data);
                  }
                }
              })
            ]
          )
        ]
      );
    },
    parentAdd() {
      this.create({ title: "", parentId: null });
    },
    create(data) {
      this.isshow = true;
      this.model.parentName = data.title;
      this.model.parentId = data.id;
    },
    save() {
      modifyArea({ areaEditDto: this.model }).then(r => {
        if (r.success) {
          this.init();
          this.isshow = false;
          this.model = {};
        }
      });
    },
    cancel() {
      this.isshow = false;
      this.model = {};
    },
    remove(root, node, data) {
      this.$Modal.confirm({
        title: "删除提示",
        content: "确定要删除么?",
        onOk: () => {
          const parms = {
            id: data.id
          };
          deleteArea(parms).then(c => {
            if (c.success) {
              this.init();
            }
          });
        }
      });
    }
  }
};
</script>
