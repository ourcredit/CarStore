import Vue from 'vue';
import Router from 'vue-router';
const _import = require('./_import_' + process.env.NODE_ENV);
import Full from '@/containers/Full';
Vue.use(Router);
export const constantRouterMap = [{
        path: '/login',
        component: _import('login/index'),
        hidden: true
    },
    {
        path: '/pages',
        redirect: '/pages/p404',
        name: 'Pages',
        component: {
            render(c) {
                return c('router-view');
            }
            // Full,
        },
        children: [{
                path: '404',
                name: 'Page404',
                component: _import('errorPages/Page404')
            },
            {
                path: '500',
                name: 'Page500',
                component: _import('errorPages/Page500')
            }
        ]
    }
];

export const asyncRouterMap = [{
        path: '/',
        redirect: '/dashboard',
        name: '首页',
        component: Full,
        children: [{
                path: '/house',
                name: '仓库管理',
                icon: 'speedometer',
                component: r => require(['views/house/index'], r)
            },
            {
                path: '/houseproduct',
                name: '仓库补货',
                icon: 'speedometer',
                component: r => require(['views/house/geration'], r)
            },
            {
                path: '/carorder',
                name: '车辆订单',
                icon: 'speedometer',
                component: r => require(['views/house/carorder'], r)
            },
            {
                path: '',
                name: '车辆管理',
                icon: 'person-stalker',
                component: {
                    render(c) {
                        return c('router-view');
                    }
                },
                children: [{
                        path: '/car',
                        name: '车辆审核',
                        icon: 'person',
                        hidden: false,
                        component: r => require(['views/cars/car'], r)
                    },
                    {
                        path: '/generation',
                        name: '提现管理',
                        icon: 'person-add',
                        component: r => require(['views/cars/generation'], r)
                    }
                ]
            },
            {
                path: '',
                name: '商品管理',
                icon: 'person-stalker',
                component: {
                    render(c) {
                        return c('router-view');
                    }
                },
                children: [{
                        path: '/product',
                        name: '商品管理',
                        icon: 'person',
                        hidden: false,
                        component: r => require(['views/products/product'], r)
                    },
                    {
                        path: '/productprice',
                        name: '提现管理',
                        icon: 'person-add',
                        component: r => require(['views/products/price'], r)
                    }
                ]
            },
            {
                path: '',
                name: '统计管理',
                icon: 'person-stalker',
                component: {
                    render(c) {
                        return c('router-view');
                    }
                },
                children: [{
                        path: '/members',
                        name: '会员信息',
                        icon: 'person',
                        hidden: false,
                        component: r => require(['views/staticial/members'], r)
                    },
                    {
                        path: '/payfor',
                        name: '会员支付订单',
                        icon: 'person-add',
                        component: r => require(['views/staticial/payfor'], r)
                    }, {
                        path: '/carreplease',
                        name: '车辆补货记录',
                        icon: 'person-stalker',
                        component: r => require(['views/staticial/carreplease'], r)
                    }, {
                        path: '/carsale',
                        name: '车辆售卖记录',
                        icon: 'person-stalker',
                        component: r => require(['views/staticial/carsale'], r)
                    }, {
                        path: '/houseship',
                        name: '仓库出货',
                        icon: 'person-stalker',
                        component: r => require(['views/staticial/houseship'], r)
                    }, {
                        path: '/shipstaticial',
                        name: '仓库出货统计',
                        icon: 'person-stalker',
                        component: r => require(['views/staticial/shipstaticial'], r)
                    }
                ]
            },
            {
                path: '',
                name: '权限管理',
                icon: 'person-stalker',
                component: {
                    render(c) {
                        return c('router-view');
                    }
                },
                children: [{
                        path: '/roles',
                        name: '角色管理',
                        icon: 'person',
                        component: r => require(['views/manager/Role'], r)
                    },
                    {
                        path: '/users',
                        name: '用户管理',
                        icon: 'person-add',
                        component: r => require(['views/manager/Account'], r)
                    },
                    {
                        path: '/userareas',
                        name: '用户区域管理',
                        icon: 'person-add',
                        component: r => require(['views/manager/userareas'], r)
                    },
                    {
                        path: '/areas',
                        name: '区域管理',
                        icon: 'person-add',
                        component: r => require(['views/manager/areas'], r)
                    }
                ]
            }
        ]
    },
    {
        path: '*',
        redirect: '/pages/404',
        hidden: true
    }
];

const temp = constantRouterMap.concat(asyncRouterMap);
export default new Router({
    mode: 'hash',
    linkActiveClass: 'open active',
    scrollBehavior: () => ({
        y: 0
    }),
    routes: temp
});