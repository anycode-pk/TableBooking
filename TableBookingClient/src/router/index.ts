import { createRouter, createWebHistory } from '@ionic/vue-router';
import { RouteRecordRaw } from 'vue-router';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    redirect: '/tabs/home',
  },
  {
    path: '/tabs/',
    component: () => import('./Tabs.vue'),
    children: [
      {
        path: '',
        redirect: 'home',
      },
      {
        path: 'home',
        component: () => import('@/views/Home.vue'),
      },
      {
        path: 'search',
        component: () => import('@/views/Search.vue'),
      },
      {
        path: 'bookings',
        component: () => import('@/views/Bookings.vue'),
      },
      {
        path: 'account',
        component: () => import('@/views/Account.vue'),
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
