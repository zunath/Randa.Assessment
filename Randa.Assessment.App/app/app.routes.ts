import { provideRouter, RouterConfig } from '@angular/router';

import { HomeComponent } from './components/homeComponent';
import { InstitutionComponent } from './components/communication/institutionComponent';

export const appRoutes = [
    { path: '', component: HomeComponent },
    { path: 'institutions', component: InstitutionComponent}
];