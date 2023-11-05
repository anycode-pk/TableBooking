<template>
  <ion-page>
    <ion-content>
      <ion-list v-for="restaurant in restaurants" :key="restaurant.id">
        <RestaurantCard :restaurant="restaurant" />
      </ion-list>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonContent, IonList } from "@ionic/vue";
import RestaurantCard from "@/views/SearchView/components/RestaurantCard.vue";
import type { Restaurant } from "@/models";
import { inject } from "vue";

const restaurants = inject("restaurants") as Restaurant[];

</script>

<style scoped>
ion-list {
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>