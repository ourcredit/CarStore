<template>
    <div class="animated fadeIn">
        <Row>
            <Col :span="8"> 单号:{{order.orderNum }}
            </Col>
            <Col :span="8"> 状态:{{order.state==null?'未完成':(order.state?'已完成':'已取消') }}
            </Col>
            <Col :span="8">
            <a @click="viewForm" v-if="order.formId">查看表单</a>
            </Col>
        </Row>
        <Row>
            <table class="gridtable">
                <thead>
                    <tr>
                        <th>商品名称</th>
                        <th>单价</th>
                        <th>个数</th>
                        <th>总价</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{{order.productName}}</td>
                        <td>{{order.price}}</td>
                        <td>{{order.count}}</td>
                        <td>{{order.totalPrice}}</td>
                    </tr>
                </tbody>
            </table>
        </Row>
        <Row>
            <Col :span="8"> 代理商名称:{{order.companyName }}
            </Col>
            <Col :span="8"> 客户名称:{{order.customerName }}
            </Col>
            <Col :span="8"> 商品总价:{{order.totalPrice }}
            </Col>
        </Row>
        <Row v-if="order.state!=null&&!order.state">
            <Col :span="2"> 订单取消原因
            </Col>
            <Col :span="22">
            <Input v-model="order.cancelReason" disabled placeholder=""></Input>
            </Col>
        </Row>
        <Row>
            <Col :span="4" offset="9">
            <Button type="ghost" @click="back" style="margin-left: 8px">返回</Button>
            <Button v-if="order.state" type="primary" @click="payback">退款</Button>
            </Col>
        </Row>
        <!-- 添加和编辑窗口 -->
        <Modal :width='800' :transfer='false' v-model='modal.isShow' :title='modal.title' ok-text="导出" :mask-closable='false' @on-ok='save'
            @on-cancel='cancel'>

  <Form ref='form' :model='form'  label-position="top">
        <div class="infoBox">
          <Row class='basic'>
            <Col span='24'>客户基本信息</Col>
          </Row>
          <div class="infoInput">
            <FormItem label="公司名称" prop='companyName'>
              <Input v-model="form.companyName"></Input>
            </FormItem>
            <FormItem label="所属行业">
              <Input v-model="form.industry"></Input>
            </FormItem>
            <FormItem label="品牌名称">
              <Input v-model="form.brands"></Input>
            </FormItem>
            <FormItem label="法人代表">
              <Input v-model="form.legalPerson"></Input>
            </FormItem>
            <FormItem label="法人代表手机号码">
              <Input v-model="form.legalMobile"></Input>
            </FormItem>
            <FormItem label="品牌负责人">
              <Input v-model="form.brandsPerson"></Input>
            </FormItem>
            <FormItem label="品牌负责人手机号码">
              <Input v-model="form.brandsMobile"></Input>
            </FormItem>
            <FormItem label="联系地址">
              <Input v-model="form.address"></Input>
            </FormItem>
            <FormItem label="邮编">
              <Input v-model="form.postNum"></Input>
            </FormItem>
            <FormItem label="电子邮箱" prop='email'>
              <Input v-model="form.email"></Input>
            </FormItem>
          </div>
        </div>
        <Row>
            <Col span="12">企业营业执照副本</Col>
            <Col span="12"></Col>
             <Row v-if="licences">
              <enlargeimg @remove="childRemove" :data="licences"></enlargeimg>
            </Row>
        </Row>

         <Row>
            <Col span="12">企业法人身份证正面</Col>
            <Col span="12"></Col>
              <Row v-if="uface">
              <enlargeimg @remove="childRemove" :data="uface"></enlargeimg>
            </Row>
        </Row>

 <Row>
            <Col span="12">企业法人身份证背面</Col>
            <Col span="12"></Col>
             <Row v-if="dface">
              <enlargeimg @remove="childRemove" :data="dface"></enlargeimg>
            </Row>
        </Row>

 <Row>
            <Col span="12">企业所属行业特有许可证或企业荣誉：</Col>
            <Col span="12"></Col>
              <Row v-if="images">
              <enlargeimg @remove="childRemove" :data="images"></enlargeimg>
            </Row>
        </Row>

       <Row>
            <Col span="12">相关资料</Col>
            <Col span="12"></Col>
             <Row v-if="files">
              <Col offset="12" span="12" :key="index" v-for="(item,index) in files"> {{item.profileName}}
              <a :href="item.profileUrl" download="w3logo">下载</a>
              </Col>
            </Row>
        </Row>


        <BackTop> </BackTop>
      </Form>
        </Modal>
    </div>
</template>

<script>
import { order, exportData, payBack, getFormByOrder } from "api/products";
import enlargeimg from "components/enlargeimg";
export default {
  name: "orderdetail",
  data() {
    return {
      order: {},
      form: {},
      modal: {
        isShow: false,
        title: "表单详情"
      }
    };
  },
  components: {
    enlargeimg
  },
  created() {
    this.init();
  },
  computed: {
    licences() {
      if (this.form.formProfiles != null) {
        return this.form.formProfiles.filter(c => {
          return c.profileType === 3;
        });
      } else {
        return [];
      }
    },
    uface() {
      if (this.form.formProfiles != null) {
        return this.form.formProfiles.filter(c => {
          return c.profileType === 4;
        });
      } else {
        return [];
      }
    },
    dface() {
      if (this.form.formProfiles != null) {
        return this.form.formProfiles.filter(c => {
          return c.profileType === 5;
        });
      } else {
        return [];
      }
    },
    images() {
      if (this.form.formProfiles) {
        return this.form.formProfiles.filter(function(x) {
          return x.profileType == 2;
        });
      } else return null;
    },
    files() {
      if (this.form.formProfiles) {
        return this.form.formProfiles.filter(function(x) {
          return x.profileType == 1;
        });
      } else return null;
    }
  },
  destroyed() {},
  methods: {
    remove(item) {
      this.form.formProfiles = this.form.formProfiles.filter(
        c => c.profileId !== item.profileId
      );
    },
    childRemove(guid) {
      deleteFile(guid);
      this.form.formProfiles = this.form.formProfiles.filter(
        c => c.profileId !== guid
      );
    },
    download(item) {
      window.open(item.profileUrl);
    },
    init() {
      order({
        id: this.$route.query.id
      })
        .then(r => {
          if (r.data.success) {
            this.order = r.data.result;
          }
        })
        .catch(e => {
          this.$Message.error(e.response.data.error.message);
        });
    },

    // 完成
    payback() {
      this.$Modal.confirm({
        title: "操作提示",
        content: "确定要退款么?",
        onOk: () => {
          const parms = {
            id: this.order.id
          };
          payBack(parms)
            .then(c => {
              if (c.data.success) {
                this.$Message.success("提交成功");
                this.$router.push({
                  path: "/orders"
                });
              }
            })
            .catch(e => {
              this.$Message.error(e.response.data.error.message);
            });
        }
      });
    },
    back() {
      this.$router.push({
        path: "/orders"
      });
    },
    save() {
      window.open(
        "http://47.93.2.82:9999/api/File/DownLoadFile?orderId=" + this.order.id
      );

      this.modal.isShow = false;
    },
    cancel() {
      this.modal.isShow = false;
    },
    viewForm() {
      getFormByOrder({
        id: this.order.id
      }).then(r => {
        if (r.data.success) {
          this.form = r.data.result;
          this.modal.isShow = true;

          this.form.orderId = this.$route.query.id;
          this.form.customerId = localStorage.getItem("Credit-Id");
          if (this.form.formProfiles == null) {
            this.form.formProfiles = [];
          }
          if (this.form.bottomIdCard) {
            const model = {
              profileId: this.form.bottomIdCard,
              profileUrl: this.form.bottomIdCardUrl,
              profileName: "",
              profileType: 5
            };
            this.form.formProfiles.push(model);
          }
          if (this.form.topIdCard) {
            const model = {
              profileId: this.form.topIdCard,
              profileUrl: this.form.topIdCardUrl,
              profileName: "",
              profileType: 4
            };
            this.form.formProfiles.push(model);
          }
          if (this.form.license) {
            const model = {
              profileId: this.form.license,
              profileUrl: this.form.licenseUrl,
              profileName: "",
              profileType: 3
            };
            this.form.formProfiles.push(model);
          }
        }
      });
    }
  }
};
</script>


<style rel='stylesheet/scss' lang="scss" scoped>
table.gridtable {
  width: 100%;
  font-family: verdana, arial, sans-serif;
  font-size: 11px;
  color: #333333;
  border-width: 1px;
  border-color: #666666;
  border-collapse: collapse;
}

table.gridtable th {
  border-width: 1px;
  padding: 8px;
  border-style: solid;
  border-color: #666666;
  background-color: #dedede;
}

table.gridtable td {
  border-width: 1px;
  padding: 8px;
  border-style: solid;
  border-color: #666666;
  background-color: #ffffff;
}

div {
  font-family: "Microsoft Yahei";
}

.g-center {
  text-align: center;
}

.Myinfo {
  .MyinfoMain {
    // background: #f5f5f6;
    padding-bottom: 35px;
    overflow: auto;
    .ivu-form-item-required .ivu-form-item-label:before {
      display: none;
    }
    .infoTitle {
      padding-top: 80px;
      padding-bottom: 40px;
      font-size: 20px;
      color: #373d41;
    }
    .infoBox {
      width: 1000px;
      margin: 0 auto;
      background: #fff;
      padding: 58px 96px;
      border-bottom: 2px solid #ebebeb;
      .basic {
        font-size: 20px;
        color: #373d41;
        margin-bottom: 46px;
      }
      .infoInput {
        width: 490px;
        margin: 0 auto;
        label {
          color: #9b9ea0;
          font-size: 14px;
        }
        input {
          height: 40px;
          border-radius: 0;
        }
      }
      .c9 {
        color: #9b9ea0;
        font-size: 14px;
        padding-top: 35px;
        margin-bottom: 8px;
      }
    }
    .infoTextArea {
      textarea.ivu-input {
        padding: 12px;
      }
    }
    .submitButton {
      margin: 120px 0 62px;
      button {
        width: 200px;
        height: 40px;
        background: #679fec;
        padding: 0;
        border: 1px solid #679fec;
        border-radius: 0;
        font-size: 14px;
      }
    }
    .fileUpload {
      width: 645px;
      img {
        height: 80px;
        border: 1px solid #c4c5c7;
      }
      .fileBox {
        width: 160px;
        height: 80px;
        line-height: 98px;
      }
      .ivu-upload-drag {
        margin: 0 auto;
        width: 160px;
        height: 80px;
        line-height: 98px;
        border: 1px solid #c4c5c7;
        border-radius: 0;
      }
      .g9b9ea0 {
        color: #9b9ea0;
        font-size: 14px;
      }
      .g-marginLeft {
        margin: 0 143px 0 36px;
      }
    }
    .myInput input {
      border-radius: 0;
      border-right: none;
    }
    .myBtn {
      border-radius: 0;
      margin-left: -3px;
      background: #4e5873;
      color: #fff;
      padding: 8px 15px;
    }
  }
}

.demo-upload-list {
  display: inline-block;
  width: 60px;
  height: 60px;
  text-align: center;
  line-height: 60px;
  border: 1px solid transparent;
  border-radius: 4px;
  overflow: hidden;
  background: #fff;
  position: relative;
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
  margin-right: 4px;
}

.demo-upload-list img {
  width: 100%;
  height: 100%;
}

.demo-upload-list-cover {
  display: none;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background: rgba(0, 0, 0, 0.6);
}

.demo-upload-list:hover .demo-upload-list-cover {
  display: block;
}

.demo-upload-list-cover i {
  color: #fff;
  font-size: 20px;
  cursor: pointer;
  margin: 0 2px;
}

.singleimg {
  margin-left: 40px;
  width: 160px;
  height: 80px;
  border: 1px solid #c4c5c7;
}
</style>

