import Vue from 'vue';
import Router from 'vue-router';
import PageNotFound from '@/views/page-not-found';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      redirect: '/user',
    },
    {
      path: '/user',
      name: 'User',
      component: () =>
        import(/* webpackChunkName: "bundle.user" */ './views/user.vue'),
    },
    {
      path: '/property-details',
      name: 'PropertyDetails',
      component: () =>
        import(/* webpackChunkName: "bundle.property-details" */ './views/property-details.vue'),
    },
    {
      path: '/product-list',
      name: 'ProductList',
      component: () =>
        import(/* webpackChunkName: "bundle.product-list" */ './views/products-list.vue'),
    },
    {
      path: '*',
      component: PageNotFound,
    },
  ],
});
