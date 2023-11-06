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

export enum priceRange {
    $,
    $$,
    $$$
}

export enum sortingMethod {
    popular,
    rating,
    distance
}

export type SearchOptions = {
    price: priceRange;
    sort: sortingMethod;
};