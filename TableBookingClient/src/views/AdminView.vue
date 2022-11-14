<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-buttons slot="start">

          <ion-back-button default-href="/tabs/home"></ion-back-button>
        </ion-buttons>
        <ion-title>Admin</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <IonList>
        <IonCard>
          <ion-card-header color="success">
            <ion-card-title>
              Create restaurant
            </ion-card-title>
          </ion-card-header>
          <ion-item>
            <ion-input v-model="restaurant.name" placeholder="name"></ion-input>
          </ion-item>
          <ion-item>
            <ion-input v-model="restaurant.type" placeholder="type"></ion-input>
          </ion-item>
          <ion-item>
            <ion-input v-model="restaurant.image" placeholder="image"></ion-input>
          </ion-item>
          <ion-item>
            <IonButton color="success" slot="end" @click="postRestaurant()">Create</IonButton>
          </ion-item>
        </IonCard>
        <IonCard>
          <ion-card-header color="primary">
            <ion-card-title>
              Edit restaurants
            </ion-card-title>
              <ion-button slot="">
                Fetch
              </ion-button>
          </ion-card-header>
          <ion-list>
            <ion-list v-for="restaurant in restaurants" :key="restaurant.id">
              <ion-item></ion-item>
            </ion-list>
          </ion-list>
        </IonCard>
      </IonList>
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {
  IonBackButton,
  IonButton, IonButtons, IonCard, IonCardHeader, IonCardTitle,
  IonContent,
  IonHeader,
  IonInput,
  IonItem,
  IonLabel,
  IonList,
  IonPage,
  IonTitle,
  IonToolbar, toastController
} from '@ionic/vue';
import { defineComponent } from 'vue';
import axios from "axios";

interface Restaurant {
  id: string,
  name: string,
  type: string,
  image: string
}

export default defineComponent({
  name: 'AdminView',
  data () {
    return{
      restaurant: {} as Restaurant,
      restaurants: [] as Restaurant[]
    }
  },
  methods: {
    async postRestaurant(){
      axios.post("https://localhost:7012/api/Restaurant", this.restaurant).then((response) => {this.presentToast(response.status)});
    },
    async presentToast(response: number) {
      let message = "Status: " + response.toString() + ((response>=200 && response<300)?" Success":" Error");
      const toast = await toastController.create({
        message: message,
        duration: 4000,
        position: 'bottom'
      });
      await toast.present();
    },
  },
  components: {
    IonContent,
    IonHeader,
    IonPage,
    IonTitle,
    IonToolbar,
    IonList,
    IonItem,
    IonButton,
    IonInput,
    IonCard,
    IonCardHeader,
    IonCardTitle,
    IonBackButton,
    IonButtons
  },
});

</script>

<style scoped>

</style>
