<template>
  <ion-page>
    <ion-content>
      <ion-tabs>
        <ion-router-outlet></ion-router-outlet>
        <ion-tab-bar slot="bottom">
          <ion-tab-button tab="home" href="/home">
            <ion-icon :icon="homeSharp" />
            <ion-label>Home</ion-label>
          </ion-tab-button>

          <ion-tab-button tab="search" href="/search">
            <ion-icon :icon="searchSharp" />
            <ion-label>Search</ion-label>
          </ion-tab-button>

          <ion-tab-button tab="bookings" href="/bookings">
            <ion-icon :icon="calendarSharp" />
            <ion-label>Bookings</ion-label>
          </ion-tab-button>

          <ion-tab-button tab="account" href="/account">
            <ion-icon :icon="personSharp" />
            <ion-label>Account</ion-label>
          </ion-tab-button>
        </ion-tab-bar>
      </ion-tabs>
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {
  IonTabBar,
  IonTabButton,
  IonTabs,
  IonContent,
  IonLabel,
  IonIcon,
  IonPage,
  IonRouterOutlet,
} from '@ionic/vue';
import { calendarSharp, personSharp, searchSharp, homeSharp } from 'ionicons/icons';

export default {
  name: 'Tabs',
  components: {
    IonContent,
    IonLabel,
    IonTabs,
    IonTabBar,
    IonTabButton,
    IonIcon,
    IonPage,
    IonRouterOutlet,
  },
  setup() {
    return {
      calendarSharp,
      personSharp,
      searchSharp,
      homeSharp
    };
  },
};
</script>