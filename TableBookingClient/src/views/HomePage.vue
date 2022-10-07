<template>
  <ion-page>
    <ion-header>
      <SearchBar/>
    </ion-header>
    
    <ion-content :fullscreen="true">

    </ion-content>

    <ion-footer>

    </ion-footer>
  </ion-page>
</template>

<script lang="ts">
import SearchBar from "@/components/SearchBar.vue";
import { IonContent, IonHeader, IonPage, IonFooter } from '@ionic/vue';
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'HomePage',
  components: {
    SearchBar,
    IonContent,
    IonHeader,
    IonFooter,
    IonPage
  }
});
</script>

<style scoped>
#container {
  text-align: center;
  
  position: absolute;
  left: 0;
  right: 0;
  top: 50%;
  transform: translateY(-50%);
}

#container strong {
  font-size: 20px;
  line-height: 26px;
}

#container p {
  font-size: 16px;
  line-height: 22px;
  
  color: #8c8c8c;
  
  margin: 0;
}

#container a {
  text-decoration: none;
}
</style>
