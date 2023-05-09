<template>
    <ion-card  :router-link='linkToRestaurant'>
      <img alt="../assets/img/RestaurantPlaceholder.jpg" src="../../../assets/img/RestaurantPlaceholder.jpg"/>
    <div class="header-row">
        <ion-card-header>
          <ion-card-subtitle>{{ props.restaurant.type || 'Type' }}</ion-card-subtitle>
          <ion-card-title>{{ props.restaurant.name || 'Name' }}</ion-card-title>
            <div class="time-container">
                <IonIcon class="time-icon" :icon="time"/>
                <IonLabel class="time-label">8:00-21:00</IonLabel>
            </div>
        </ion-card-header>
            <div class="card-buttons">
                <ion-button @click.stop="likeRestaurant" fill="clear">
                    <ion-icon slot="icon-only" :icon="heartSharp"/>
                </ion-button>
                <ion-button  fill="clear">
                    <ion-icon slot="icon-only" :icon="shareSharp"/>
                </ion-button>
            </div>
        </div>
        <ion-card-content>
            <p>{{ props.restaurant.shortDescription || 'Short description' }}</p>
        </ion-card-content>
    </ion-card>
</template>

<script setup lang="ts">
import {IonCard, IonCardHeader, IonCardSubtitle, IonCardTitle, IonButton, IonIcon, IonLabel, IonNavLink} from "@ionic/vue";
import {heartSharp, shareSharp, time} from "ionicons/icons";
import { defineProps } from "vue";
import type { Restaurant } from "@/models";
import router from "@/router";

const props = defineProps<{
  restaurant: Restaurant
}>();

const linkToRestaurant = `/restaurant/${props.restaurant.id}`;
const likeRestaurant = () => {
  console.log("Like restaurant");
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
</style>