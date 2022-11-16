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
        name: 'Home',
        path: 'home',
        component: () => import('@/views/HomeView.vue'),
      },
      {
        name: 'Search',
        path: 'search',
        component: () => import('@/views/SearchView.vue'),
      },
      {
        name: 'Bookings',
        path: 'bookings',
        component: () => import('@/views/BookingsView.vue'),
      },
      {
        name: 'Account',
        path: 'account',
        component: () => import('@/views/AccountView.vue'),
      },
    ],
  },
  {
    name: 'Restaurant',
    path: '/restaurant/:id',
    props: true,
    component: () => import('@/views/RestaurantView.vue'),
  },
  {
    name: 'Admin',
    path: '/admin',
    component: () => import('@/views/AdminView.vue'),
  },
  {
    name: "Welcome",
    path: '/welcome',
    component: () => import('@/views/WelcomeView.vue'),
  },
  {
    name: "SignIn",
    path: '/signin',
    component: () => import('@/views/SignInView.vue'),
  },
  {
    name: "SignUp",
    path: '/signup',
    component: () => import('@/views/SignUpView.vue'),
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
