<template>
  <ion-page>
    <ion-header>
      <SearchBar/>
    </ion-header>
    <ion-content>

      <RestaurantCard/>

    </ion-content>
  </ion-page>
</template>

<script>
import SearchBar from "@/components/SearchBar";
import {IonPage, IonContent, IonHeader} from "@ionic/vue";
import { defineComponent } from 'vue';
import RestaurantCard from "@/components/RestaurantCard";

export default defineComponent({
  name: 'Search',
  components: {
    RestaurantCard,
    IonContent,
    IonPage,
    SearchBar,
    IonHeader,
  }
});
</script>

<style scoped>

</style>