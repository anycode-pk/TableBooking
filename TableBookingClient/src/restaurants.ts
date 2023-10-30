import {Restaurant} from "@/models";
import {LoremIpsum} from "lorem-ipsum";

const loremIpsum :string = new LoremIpsum({
    sentencesPerParagraph: {
        max: 8,
        min: 4
    },
    wordsPerSentence: {
        max: 16,
        min: 4
    }
}).generateParagraphs(1);
const shortIpsum :string = new LoremIpsum({
    sentencesPerParagraph: {
        max: 3,
        min: 2
    },
    wordsPerSentence: {
        max: 16,
        min: 4
    }
}).generateParagraphs(1);
export const restaurantPlaceholders :Restaurant[] = [
    {
        id: "1",
        name: "Restaurant",
        type: "Type",
        description: loremIpsum,
        shortDescription: shortIpsum,
        primaryImageUrl: "https://picsum.photos/700/300?random=1",
        openTime: "10:00",
        closeTime: "22:00",
        location: "Location",
        rating: 4.7,
        phone: "123123123",
        email: "restaurant@email.com",
        website: "www.restaurant.com",
    } as Restaurant,
    {
        id: "2",
        name: "KrowaBurger",
        type: "Burger",
        description: loremIpsum,
        shortDescription: shortIpsum,
        primaryImageUrl: "https://picsum.photos/700/300?random=2",
        openTime: "10:00",
        closeTime: "22:00",
        location: "Location",
        rating: 3.5,
        phone: "123123123",
        email: "restaurant@email.com",
        website: "www.restaurant.com",
    } as Restaurant,
];