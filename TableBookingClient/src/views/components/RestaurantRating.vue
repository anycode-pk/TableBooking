<template>
    <div class="rating">
        <p style="margin: 5px">{{rating}}</p>
        <ion-icon v-for="star in 5" :key="star" :icon="starIcon" :style="getStarColor(star)"></ion-icon>
    </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue';
import { IonIcon } from '@ionic/vue';
import { starSharp as starIcon } from 'ionicons/icons';

const props = defineProps({
    rating: {
        type: Number,
        required: true,
        validator: (value: number) => value >= 1 && value <= 5
    }
});
const getStarColor = (star: number): Record<string, string> => {
    return {
        color: star <= props.rating ? 'yellow' : 'inherit'
    };
};
</script>

<style scoped>
.rating {
    display: flex;
    align-items: center;
}
</style>
