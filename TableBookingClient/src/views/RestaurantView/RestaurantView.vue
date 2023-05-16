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
            <img alt="Restaurant image" v-bind:src="restaurant.imageUrl"/>
            <div class="header-row">
                <ion-card-header>
                    <RestaurantRating v-bind:rating="restaurant.rating"/>
                    <ion-card-title>{{ restaurant.name || 'Name' }}</ion-card-title>
                    <ion-card-subtitle>{{ restaurant.type || 'Type' }}</ion-card-subtitle>
                    <div class="time-container">
                        <IonIcon class="time-icon" :icon="time"/>
                        <IonLabel class="time-label">{{ restaurant.openTime + '-' + restaurant.closeTime }}</IonLabel>
                    </div>
                </ion-card-header>
                <div class="card-buttons">
                    <ion-button @click.stop="likeRestaurant" fill="clear">
                        <ion-icon slot="icon-only" :icon="heartSharp"/>
                    </ion-button>
                    <ion-button @click.stop="shareRestaurant" fill="clear">
                        <ion-icon slot="icon-only" :icon="shareSharp"/>
                    </ion-button>
                </div>
            </div>
            <ion-card-content>
                <p>{{ restaurant.description || 'Description' }}</p>
                <ion-button :router-link='bookTable'>
                    <ion-icon slot="start" :icon="time"></ion-icon>
                    <ion-label>Book a table</ion-label>
                </ion-button>
            </ion-card-content>
        </ion-card>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">

import {IonPage, IonIcon, IonCardContent, IonLabel, IonCard, IonCardTitle, IonCardHeader, IonCardSubtitle, IonButton, IonBackButton, IonButtons, IonTitle, IonHeader, IonContent, IonToolbar, } from "@ionic/vue";
import {heartSharp, shareSharp, time} from "ionicons/icons";
import type { Restaurant } from "@/models";
import {LoremIpsum} from "lorem-ipsum";
import axios from "axios";
import {onMounted} from "vue";
import {restaurantPlaceholders} from "@/restaurants";
import RestaurantRating from "@/views/components/RestaurantRating.vue";

let restaurant :Restaurant;
restaurant = restaurantPlaceholders[0];

async function getRestaurant(): Promise<void>{
    const getRestaurantsResponse = await axios.get<Restaurant>('https://localhost:7012/api/Restaurant/' + restaurant.id);
    let restaurantData : Restaurant = getRestaurantsResponse.data;
    if (restaurantData){
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
};

</script>

<style scoped>
  /*Display the restaurant card in the center center of the page in the middle*/
  ion-card {
    margin: 10px auto;
    height: auto;
    max-width: calc(100% - 20px);
  }
  #time{
    float: right;
  }
  img{}
  ion-card-subtitle{
      margin: 0;
  }

  ion-card-content{
      padding-top: 0;
  }

</style>
