declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/student', title: 'Student',  icon: 'man', class: '' },
    { path: '/subject', title: 'Subject',  icon:'subject', class: '' },
];