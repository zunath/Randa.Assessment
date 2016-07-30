import { provideRouter, RouterConfig } from '@angular/router';

import { MessageListComponent } from './components/messageList';
import { HomeComponent } from './components/home';

export const appRoutes = [
    { path: '', component: HomeComponent},
    { path: 'messageList/id', component: MessageListComponent}
];