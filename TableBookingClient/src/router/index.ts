import { createRouter, createWebHistory } from '@ionic/vue-router';
import { RouteRecordRaw } from 'vue-router';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    redirect: '/home',
  },
  {
    path: '/',
    component: () => import('./NavBar.vue'),
    children: [
      {
        path: '',
        redirect: '/home',
      },
      {
        name: 'Home',
        path: 'home',
        component: () => import('@/views/HomeView/HomeView.vue'),
      },
      {
        path: 'search',
        component: () => import('@/views/SearchView/SearchView.vue'),
        children: [
          {
            path: '',
            redirect: '/search/list',
          },
          {
            name: 'list',
            path: 'list',
            component: () => import('@/views/SearchView/SearchListView.vue'),
          },
          {
            name: 'map',
            path: 'map',
            component: () => import('@/views/SearchView/SearchMapView.vue'),
          }
        ],
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
      {
        name: 'Restaurant',
        path: 'restaurant/:id',
        props: true,
        component: () => import('@/views/RestaurantView/RestaurantView.vue'),
      },
      {
        name: 'BookRestaurant',
        path: 'book/:id',
        props: true,
        component: () => import('@/views/BookRestaurantView/BookRestaurantView.vue'),
      },
      {
        name: 'BookSuccess',
        path: 'book/success',
        component: () => import('@/views/BookRestaurantView/BookSuccessView.vue'),
      },
      {
        name: 'Admin',
        path: 'admin',
        component: () => import('@/views/AdminView.vue'),
      },
      {
        name: "Welcome",
        path: 'welcome',
        component: () => import('@/views/WelcomeView.vue'),
      },
      {
        name: "SignIn",
        path: 'signin',
        component: () => import('@/views/SignInView.vue'),
      },
      {
        name: "SignUp",
        path: 'signup',
        component: () => import('@/views/SignUpView.vue'),
      }
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
