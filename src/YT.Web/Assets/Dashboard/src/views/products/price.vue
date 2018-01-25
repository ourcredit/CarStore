<template>
  <div class="animated fadeIn">
    <Row>
      <milk-table ref="list" :layout="[18,2,2]" :columns="cols" :search-api="searchApi" :params="params">
        <template slot="search">
          <Form ref="params" :model="params" inline :label-width="60">
            <FormItem label="区域名">
              <Input v-model="params.filter" placeholder="区域名"></Input>
            </FormItem>
          </Form>
        </template>
      </milk-table>
    </Row>
    <!-- 添加和编辑窗口 -->
    <Modal :width="800" :transfer="false" v-model="isshow" title="编辑价格" :mask-closable="false"
     @on-ok="cancel" @on-cancel="cancel">
        <table>
          <thead>
            <tr>
              <th>商品名称</th>
              <th>商品编号</th>
              <th>成本价格</th>
              <th>价格</th>
            </tr>
          </thead>
        </table>
    </Modal>
  </div>
</template>

<script>
import { getAreas, getAreaPrice } from "api/area";
export default {
  name: "price",
  data() {
    return {
      cols: [
        {
          title: "一级区域",
          key: "parentName"
        },
        {
          title: "二级区域",
          key: "areaName"
        },
        {
          title: "状态",
          key: "state",
          render: (h, params) => {
            return params.row.state ? "已设置" : "未设置";
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
                    this.editShow(params.row);
                  }
                }
              },
              "编辑价格"
            );
            divs.push(del);
            return h("div", divs);
          }
        }
      ],
      isshow: false,
      searchApi: getAreas,
      params: {
        filter: "",
        level: 25
      },
      list: []
    };
  },
  components: {},
  created() {},
  destroyed() {},
  methods: {
    editShow(row) {
      this.isshow = true;
      getAreaPrice({ id: row.id }).then(r => {
        if (r.result) {
          this.list = r.result;
        }
      });
    },
    cancel() {
      this.isshow = false;
    }
  }
};
</script>

<style type="text/css" scoped>

</style>