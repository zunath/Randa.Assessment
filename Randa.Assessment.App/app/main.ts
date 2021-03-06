﻿import { bootstrap }    from '@angular/platform-browser-dynamic';
import { provideRouter } from '@angular/router';
import { HTTP_PROVIDERS } from '@angular/http';

import { AppComponent } from './app';
import { appRoutes } from './app.routes';

bootstrap(AppComponent, [
    provideRouter(appRoutes),
    HTTP_PROVIDERS
]);