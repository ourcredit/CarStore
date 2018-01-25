import {
  Authenticate,
  getInfo
} from 'api/login';
// import Cookies from 'js-cookie';

const user = {
  state: {
    userName: '',
    token: sessionStorage.getItem('Milk-Token'),
    name: '',
    avatar: '',
    emailAddress: ''
  },

  mutations: {
    SET_TOKEN: (state, token) => {
      state.token = token;
    },
    SET_USERNAME: (state, userName) => {
      state.userName = userName;
    },
    SET_NAME: (state, name) => {
      state.name = name;
    },
    SET_AVATAR: (state, avatar) => {
      state.avatar = avatar;
    },
    SET_EMAIL: (state, emailAddress) => {
      state.emailAddress = emailAddress;
    },
    LOGIN_SUCCESS: () => {
      console.log('login success');
    },
    LOGOUT_USER: state => {
      state.user = '';
    }
  },
  actions: {
    // 邮箱登录
    LoginByEmail({
      commit
    }, userInfo) {
      const email = userInfo.usernameOrEmailAddress.trim();
      return new Promise((resolve, reject) => {
        Authenticate(email, userInfo.password)
          .then(response => {
            sessionStorage.setItem('Milk-Token', response.result);
            //    Cookies.set('Admin-Token', response.data.token);
            commit('SET_TOKEN', response.result);
            commit('SET_USERNAME', email);
            resolve();
          })
          .catch(error => {
            reject(error);
          });
      });
    },
    // 获取用户信息
    GetInfo({
      commit
    }) {
      return new Promise((resolve, reject) => {
        getInfo()
          .then(response => {
            const data = response.result;
            commit('SET_EMAIL', data.user.emailAddress);
            commit('SET_NAME', data.user.name);
            commit('SET_AVATAR', data.user.profilePictureId);
            commit('SET_USERNAME', data.user.userName);
            resolve(response);
          })
          .catch(error => {
            reject(error);
          });
      });
    },
    // 登出
    LogOut({
      commit
    }) {
      return new Promise(resolve => {
        commit('SET_TOKEN', '');
        sessionStorage.clear();
        resolve();
      });
    },
    // 前端 登出
    FedLogOut({
      commit
    }) {
      return new Promise(resolve => {
        commit('SET_TOKEN', '');
        sessionStorage.clear();
        resolve();
      });
    }
  }
};

export default user;