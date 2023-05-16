<template>
    <ion-card  :router-link='linkToRestaurant'>
      <img class="restaurant-card-image" alt="Restaurant image" v-bind:src="restaurant.imageUrl"/>
    <div class="header-row">
        <ion-card-header>
            <RestaurantRating v-bind:rating="restaurant.rating"/>
            <ion-card-title>{{ props.restaurant.name || 'Name' }}</ion-card-title>
            <ion-card-subtitle>{{ restaurant.type || 'Type' }}</ion-card-subtitle>
            <div class="time-container">
                <IonIcon class="time-icon" :icon="time"/>
                <IonLabel class="time-label">{{ restaurant.openTime + '-' + restaurant.closeTime }}</IonLabel>
            </div>
        </ion-card-header>
        <div class="header-column">
            <div class="card-buttons">
                <ion-button @click.stop="likeRestaurant" fill="clear">
                    <ion-icon slot="icon-only" :icon="heartSharp"/>
                </ion-button>
                <ion-button @click.stop="shareRestaurant" fill="clear">
                    <ion-icon slot="icon-only" :icon="shareSharp"/>
                </ion-button>
            </div>
        </div>
        </div>
    </ion-card>
</template>

<script setup lang="ts">
import {IonCard, IonCardHeader, IonCardSubtitle, IonCardTitle, IonButton, IonIcon, IonLabel, IonNavLink} from "@ionic/vue";
import {heartSharp, shareSharp, time} from "ionicons/icons";
import { defineProps } from "vue";
import type { Restaurant } from "@/models";
import RestaurantRating from "@/views/components/RestaurantRating.vue";

const props = defineProps<{
  restaurant: Restaurant
}>();

const linkToRestaurant = `/restaurant/${props.restaurant.id}`;
const likeRestaurant = () => {
  console.log("Like restaurant");
};
const shareRestaurant = () => {
  console.log("Share restaurant");
};

</script>

<style>

  @media (min-width: 768px) {
    ion-card {
      width: 50%;
    }
    img {
      width: 100%;
      height: 200px;
      object-fit: cover;
    }
  }
  @media (max-width: 768px) {
      ion-card {
          width: calc(100% - 20px);
      }
  }
  ion-card-subtitle{
      margin: 0;
  }

  .header-row {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    height: 100%;
      align-items: center;
  }
  .card-buttons {
    display: flex;
    flex-direction: row-reverse;
    align-items: center;
    width: 50%;
  }
  .card-content-row{
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
  }
  .time-container{
      display: flex;
      flex-direction: row;
      align-items: center;
  }
  .time-icon{
      height: 24px;
  }
  .time-label{
      padding: 5px;
      margin-top: 2px;
  }
  .restaurant-card-image{
    width: 100%;
    height: 200px;
    object-fit: cover;
  }

  .header-column {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    height: 100%;
  }

  ion-card-title{
      margin: 0;
  }
</style>