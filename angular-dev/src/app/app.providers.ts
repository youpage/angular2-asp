import { bind } from '@angular/core';
import { HTTP_PROVIDERS } from '@angular/http';
import { FORM_PROVIDERS, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { ROUTER_PROVIDERS } from '@angular/router';

import { Sorter } from './shared/utils/sorter';
import { HttpUtils } from './shared/utils/httpUtils';
import { DataService } from './shared/services/data.service';
import { TrackByService } from './shared/services/trackby.service';

export const APP_PROVIDERS = [
    Sorter,
    HttpUtils,
    DataService,
    TrackByService,
    FORM_PROVIDERS,
    ROUTER_PROVIDERS,
    HTTP_PROVIDERS, 
];