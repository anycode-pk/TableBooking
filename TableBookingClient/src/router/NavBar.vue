<template>
  <ion-page>
    <ion-content>
      <ion-tabs>
        <ion-router-outlet></ion-router-outlet>
        <ion-tab-bar slot="bottom">

          <ion-tab-button class="tb-btn" tab="home" href="/home">
            <ion-img src="https://tb.hu1.pl/assets/icon/favicon.png"></ion-img>
            <ion-label class="tb-label">TBApp</ion-label>
          </ion-tab-button>

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

          <ion-tab-button tab="account" href="/account" class="tb-account">
            <ion-icon :icon="personSharp" />
            <ion-label class="account-label">Account</ion-label>
          </ion-tab-button>
        </ion-tab-bar>
      </ion-tabs>
    </ion-content>
  </ion-page>
</template>

<style>
ion-tab-button {
  --color-selected: #ff6e6e;
}


ion-tab-bar {
  border: 2px solid rgb(44, 38, 38) !important;
}

ion-list {
  margin-left: 1500px;
}

.tb-label {
  display: none;
}


.account-label {
  display: none;
}

:root {
  --width-left-menu: 80px;
}



@media only screen and (min-width: 1024px) {

  .tb-label {
    display: block;

  }

  .tb-btn {
    margin-bottom: 220px;
  }

  .tb-account {
    margin-top: 200px;
  }



  .inner-scroll {
    margin-left: 200px;
  }

  ion-img {
    width: 40px;
  }

  .btn {
    display: flex;
    align-items: center;
    justify-content: center
  }


  .custom-button-content {
    display: flex;
  }


  .custom-tab ion-icon {
    margin-right: 5px;
  }


  ion-tab-bar {
    position: absolute;
    width: 80px;
    height: 100vh;
    display: flex;
    flex-direction: column;
    gap: 0 !important;
    flex: 15%;

  }

  ion-tab-button {
    max-width: inherit;
  }

  ion-title {
    font-size: 1.5em;
    padding: 20px;
  }

  ion-label {
    font-size: 10px;
    margin: 15px;
  }

  ion-header,
  ion-card,
  ion-list,
  ion-card {
    margin-left: 80px;

  }



  ion-icon {
    font-size: 1.5rem;
  }

  ion-tab-button {
    margin: 0;
    padding: 0;
    display: flex;
    flex-direction: column;
    flex-wrap: wrap;

  }

  ion-list,
  ion-card {
    margin-left: 80px !important;
  }

  ion-card {
    max-width: 1600px;
    padding: 40px;
  }

  ion-list {
    background-color: #121212 !important;

  }
}
</style>

<script setup lang="ts">

import {
  IonTabBar,
  IonTabButton,
  IonTabs,
  IonContent,
  IonLabel,
  IonIcon,
  IonPage,
  IonRouterOutlet,
  IonImg
} from '@ionic/vue';
import { calendarSharp, personSharp, searchSharp, homeSharp } from 'ionicons/icons';
import { defineComponent } from 'vue';

defineComponent({
  name: 'NavBar',
  components: {
    IonTabBar,
    IonTabButton,
    IonTabs,
    IonContent,
    IonLabel,
    IonIcon,
    IonPage,
    IonRouterOutlet,
  },
});
</script>