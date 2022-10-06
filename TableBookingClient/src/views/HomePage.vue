<template>
  <ion-page>

    <ion-header>
      <ion-toolbar>
        <ion-searchbar></ion-searchbar>
        <ion-buttons slot="primary">
          <ion-button>
            <ion-icon :icon="ellipsisHorizontal"></ion-icon>
          </ion-button>
        </ion-buttons>
      </ion-toolbar>
    </ion-header>
    
    <ion-content :fullscreen="true">

    </ion-content>

    <ion-footer>
      <bottom-navigation></bottom-navigation>
    </ion-footer>

  </ion-page>
</template>

<script lang="ts">
import { IonContent, IonSearchbar, IonHeader, IonPage, IonToolbar, IonIcon } from '@ionic/vue';
import { ellipsisHorizontal } from 'ionicons/icons';
import { defineComponent } from 'vue';
import bottom-navigation from 'components/bottom-navigation.vue';

export default defineComponent({
  name: 'HomePage',
  components: {
    IonContent,
    IonHeader,
    IonPage,
    IonToolbar,
    IonSearchbar,
    IonIcon
  },
  setup() {
    return { ellipsisHorizontal };
  },
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
