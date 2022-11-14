<template>
  <ion-page>
    <ion-content>
      <div id="WelcomeImageContainer">
        <img src="../assets/img/WelcomeImage.png"></div>
      <ion-card-header class="ion-header"> Welcome! </ion-card-header>
      <ion-card-subtitle class="ion-subtitle"> We are happy to see you. </ion-card-subtitle>
      <div id="ButtonsForSigningInContainer"> <ion-button class="ion-sign-in-button" shape="round" fill="" size="large" > Sign in </ion-button> </div>
      <div id="ButtonsForSigningUpContainer"> <ion-button class="ion-sign-up-button" shape="round" fill="" size="large" > Sign up </ion-button> </div>
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {IonContent, IonPage, IonButton} from '@ionic/vue';
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'WelcomeView',
  components: {
    IonContent,
    IonPage,
    IonButton,
  },
});

</script>

<style scoped>

ion-content {
  --ion-background-color: rgba(253, 196, 181, 0.85);
}

ion-button {
  color: #775946;
  --background: #ffa680;
  --background-hover: #f89079;
  --background-activated: #f19667;
  //--background-focused: #88f4be;
}


#WelcomeImageContainer{
  background-color: #f87474;
}

#ButtonsForSigningInContainer{
  text-align: center;
  --border-color: #b24848;
  color: #b24848;
}

#ButtonsForSigningUpContainer{
  text-align: center;
}

</style>
