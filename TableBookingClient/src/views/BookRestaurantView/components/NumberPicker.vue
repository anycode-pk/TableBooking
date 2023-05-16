<template>
    <ion-item>
        <ion-label>Number of Guests</ion-label>
        <div class="guests-wrapper">
            <ion-button @click="decreaseGuests" :disabled="selectedGuests === 1">
                <ion-icon :icon="removeSharp"></ion-icon>
            </ion-button>
            <div class="guests-count">{{ selectedGuests }}</div>
            <ion-button @click="increaseGuests" :disabled="selectedGuests === 10">
                <ion-icon :icon="addSharp"></ion-icon>
            </ion-button>
        </div>
    </ion-item>
</template>

<script setup lang="ts">
import { IonItem, IonLabel, IonButton, IonIcon } from '@ionic/vue';
import { ref } from 'vue';
import { addSharp, removeSharp } from 'ionicons/icons';

const selectedGuests = ref(1);

function increaseGuests() {
    if (selectedGuests.value < 10) {
        selectedGuests.value++;
    }
}

function decreaseGuests() {
    if (selectedGuests.value > 1) {
        selectedGuests.value--;
    }
}
</script>

<style scoped>
.guests-wrapper {
    display: flex;
    align-items: center;
}

.guests-count {
    margin: 0 8px;
    font-weight: bold;
    font-size: 16px;
}
</style>
