<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-buttons slot="start">
          <ion-back-button></ion-back-button>
        </ion-buttons>
        <ion-title>{{ restaurant.name }}</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-card>
        <img alt="Restaurant image" v-bind:src="restaurant.imageUrl" />
        <div class="header-row">
          <ion-card-header id="card-header">
            <ion-card-subtitle>{{ restaurant.type || 'Type' }}</ion-card-subtitle>
            <ion-card-title class="card-title">{{ restaurant.name || 'Name' }}</ion-card-title>
            <div class="time-container">
              <IonLabel class="time-label">{{ restaurant.openTime + '-' + restaurant.closeTime }}</IonLabel>
              <IonIcon class="time-icon" :icon="time" />
            </div>
            <RestaurantRating v-bind:rating="restaurant.rating" />
          </ion-card-header>
          <div class="card-buttons">
            <ion-button @click.stop="likeRestaurant" fill="clear">
              <ion-icon slot="icon-only" :icon="heartSharp" />
            </ion-button>
            <ion-button @click.stop="shareRestaurant" fill="clear">
              <ion-icon slot="icon-only" :icon="shareSharp" />
            </ion-button>
          </div>
        </div>
        <ion-card-content>
          <p id="description">{{ restaurant.description || 'Description' }}</p>
          <ion-button id="button-book" @click="bookTable">
            <ion-icon slot="start" :icon="time"></ion-icon>
            <ion-label>Book a table</ion-label>
          </ion-button>
        </ion-card-content>
      </ion-card>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">

import { IonPage, IonIcon, IonCardContent, IonLabel, IonCard, IonCardTitle, IonCardHeader, IonCardSubtitle, IonButton, IonBackButton, IonButtons, IonTitle, IonHeader, IonContent, IonToolbar, } from "@ionic/vue";
import { heartSharp, shareSharp, time } from "ionicons/icons";
import type { Restaurant } from "@/models";
import RestaurantRating from "../components/RestaurantRating.vue"
import axios from "axios";
import { onMounted } from "vue";
import { restaurantPlaceholders } from "@/restaurants";

let restaurant: Restaurant;
restaurant = restaurantPlaceholders[0];

async function getRestaurant(): Promise<void> {
  const getRestaurantsResponse = await axios.get<Restaurant>('https://localhost:7012/api/Restaurant/' + restaurant.id);
  let restaurantData: Restaurant = getRestaurantsResponse.data;
  if (restaurantData) {
    restaurant = restaurantData;
  }
}
onMounted(async () => {
  await getRestaurant();
})

const bookTable = '/book/' + restaurant.id;

const likeRestaurant = () => {
    console.log("Like restaurant");
};
const shareRestaurant = () => {
    console.log("Share restaurant");
const bookTable = () => {
  console.log("Book table");
  //TODO: Route to book table
};

</script>

<style scoped>
/*Display the restaurant card in the center center of the page in the middle*/
ion-card {
  margin: 10px auto;
  height: auto;
  max-width: calc(100% - 20px);
}

#time {
  float: right;
}

ion-card-subtitle {
  margin: 0;
}

.time-label {
  padding-left: 0;
  margin: 0;
}

.card-title {
  margin-top: 2px;
}

#card-header {
  padding-bottom: 0;
}

#button-book {
  margin-top: 13px;
}

#description {
  margin: 0;
}
</style>
