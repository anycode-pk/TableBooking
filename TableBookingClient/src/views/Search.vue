<template>
  <ion-page>
    <ion-header>
      <SearchBar/>
    </ion-header>
    <ion-content :fullscreen="true">
      <!-- content -->
    </ion-content>
  </ion-page>
</template>

<script>
import SearchBar from "@/components/SearchBar";
import { IonPage, IonContent, IonHeader } from "@ionic/vue";
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'Search',
  components: {
    IonContent,
    IonPage,
    SearchBar,
    IonHeader
  }
});
</script>

<style scoped>

</style>