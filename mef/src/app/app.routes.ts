import { Routes } from '@angular/router';
import { AuthService } from './services/auth.service';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./ui/pages/main/main.component'),
    canActivate: [AuthService],
    loadChildren: () =>
      import('./ui/modules/main/main.module').then((m) => m.MainModule),
  },
  {
    path: 'login',
    loadComponent: () => import('./ui/pages/login/login.component'),
  },
];
