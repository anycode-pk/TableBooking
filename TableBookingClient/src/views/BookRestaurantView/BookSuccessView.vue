<template>
    <ion-page>
        <ion-content>
            <ion-card class="success-card">
                <ion-card-header>
                    <ion-card-title>Table Booking Successful!</ion-card-title>
                </ion-card-header>
                <ion-card-content>
                    <p>Your table has been booked successfully.</p>
                </ion-card-content>
            </ion-card>

            <ion-card class="booking-card">
                <ion-card-header>
                    <ion-card-title>Booking Information</ion-card-title>
                </ion-card-header>
                <ion-card-content>
                    <p><strong>Name:</strong> {{ booking.name }}</p>
                    <p><strong>Date:</strong> {{ booking.date }}</p>
                    <p><strong>Time:</strong> {{ booking.time }}</p>
                    <p><strong>Number of Guests:</strong> {{ booking.guests }}</p>
                    <div id="button">
                        <ion-button @click="goToAccountBookings" fill="clear" >
                            <ion-icon :icon="bookmarksSharp"></ion-icon>
                            My Bookings
                        </ion-button>
                        <ion-button @click="goBackToBrowsing" fill="clear" >
                            <ion-icon :icon="listSharp"></ion-icon>
                            Book another
                        </ion-button>
                    </div>
                </ion-card-content>
            </ion-card>
        </ion-content>
    </ion-page>
</template>

<script setup>
import { IonPage, IonContent, IonCard, IonCardHeader, IonCardTitle, IonCardContent, IonButton, IonIcon } from '@ionic/vue';
import { listSharp, bookmarksSharp } from 'ionicons/icons';
import { useRouter } from 'vue-router';

const booking = {
    name: 'John Doe',
    date: '2023-05-16',
    time: '19:30',
    guests: 4,
};

const router = useRouter();

const goToHomePage = () => {
    router.push('/');
};
const goBackToBrowsing = () => {
    router.push('/search');
};
const goToAccountBookings = () => {
    router.push('/account/bookings');
};
</script>

<style scoped>
#button {
    display: flex;
    justify-content: center;
    margin-top: 1rem;
}
</style>
