<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Account</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
    <ion-list>
      <ion-item button router-link="/admin">
        <ion-label>Admin</ion-label>
      </ion-item>
    </ion-list>
    </ion-content>
  </ion-page>
</template>

<script>
import {IonPage, IonContent, IonTitle, IonHeader, IonToolbar, IonList, IonItem, IonButton, IonLabel} from "@ionic/vue";
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'AccountView',
  components: {
    IonContent,
    IonPage,
    IonTitle,
    IonHeader,
    IonToolbar,
    IonList,
    IonItem,
    IonLabel
  }
});
</script>

<style scoped>

</style>