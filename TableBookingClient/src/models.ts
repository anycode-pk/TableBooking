export type Restaurant = {
    id: string;
    name: string;
    type: string;
    openTime: string;
    closeTime: string;
    rating: number;
    shortDescription?: string;
    description?: string;
    primaryImageUrl: string;
    secondaryImageUrl: string;
    location: string;
    phone: string;
    website: string;
    email: string;
}