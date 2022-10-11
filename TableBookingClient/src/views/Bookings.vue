<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Bookings</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>

    </ion-content>
  </ion-page>
</template>

<script>
import {IonPage, IonContent, IonTitle, IonHeader, IonToolbar} from "@ionic/vue";
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'Bookings',
  components: {
    IonContent,
    IonPage,
    IonTitle,
    IonHeader,
    IonToolbar
  }
});
</script>

<style scoped>

</style>