<template>
  <ion-app>
    <ion-router-outlet>

    </ion-router-outlet>
  </ion-app>
</template>

<script setup lang="ts">

import { IonApp, IonRouterOutlet } from '@ionic/vue';
import { defineComponent } from 'vue';

defineComponent({
  name: 'App',
  components: {
    IonApp,
    IonRouterOutlet,
  },
});

</script>