<template>
  <ion-page>
    <ion-header>
      <SearchBar/>
    </ion-header>
    <ion-content>
      <ion-router-outlet>
        <!-- <router-view /> -->
      </ion-router-outlet>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
  import { IonPage, IonHeader, IonContent } from "@ionic/vue";
  import SearchBar from "@/views/SearchView/components/SearchBar.vue";
  import IonRouterOutlet from "@/App.vue";
</script>

<style scoped>

</style>