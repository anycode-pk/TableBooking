<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Bookings</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-list>
        <ion-button expand="full">
          Promos
        </ion-button>
        <ion-button expand="full">
          Help
        </ion-button>
        <ion-button expand="full">
          About
        </ion-button>
        <ion-button expand="full">
          Settings
        </ion-button>
      </ion-list>
    </ion-content>
  </ion-page>
</template>

<script>
import {IonPage, IonContent, IonTitle, IonHeader, IonToolbar, IonList, IonItem, IonIcon, IonButton} from "@ionic/vue";
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'Account',
  components: {
    IonContent,
    IonPage,
    IonTitle,
    IonHeader,
    IonToolbar,
    IonList,
    IonButton,
  }
});
</script>

<style scoped>
  ion-button{

  }
</style>