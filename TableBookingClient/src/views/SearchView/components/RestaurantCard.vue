<template>
    <ion-card :router-link='linkToRestaurant'>
      <img alt="../assets/img/RestaurantPlaceholder.jpg" src="../../../assets/img/RestaurantPlaceholder.jpg"/>
      <ion-toolbar>
        <ion-buttons slot="primary">
          <ion-button fill="clear">
            <ion-icon slot="icon-only" :icon="heartSharp"/>
          </ion-button>
          <ion-button fill="clear">
            <ion-icon slot="icon-only" :icon="shareSharp"/>
          </ion-button>
        </ion-buttons>
        <ion-card-header>
          <ion-card-title>{{ props.restaurant.name || 'Name' }}</ion-card-title>
          <ion-card-subtitle>{{ props.restaurant.type || 'Type' }}</ion-card-subtitle>
        </ion-card-header>
      </ion-toolbar>
    </ion-card>
</template>

<script setup lang="ts">
import { IonCard, IonCardHeader, IonCardSubtitle, IonCardTitle, IonToolbar, IonButtons, IonButton, IonIcon } from "@ionic/vue";
import { heartSharp, shareSharp } from "ionicons/icons";
import { defineProps } from "vue";
import type { Restaurant } from "@/models";

const props = defineProps<{
  restaurant: Restaurant
}>();

const linkToRestaurant = "/restaurant/" + props.restaurant.id;
</script>

<style>

  @media (min-width: 768px) {
    ion-card {
      width: 50%;
      height: 300px;
    }
    img {
      width: 100%;
      height: 200px;
      object-fit: cover;
    }
  }
</style>