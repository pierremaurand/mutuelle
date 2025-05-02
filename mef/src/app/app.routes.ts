import { Routes } from '@angular/router';
import { AuthService } from './services/auth.service';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  {
    path: 'login',
    loadComponent: () => import('./ui/pages/login/login.component'),
  },
  {
    path: 'home',
    canActivate: [AuthService],
    loadChildren: () =>
      import('./ui/modules/main/main.module').then((m) => m.MainModule),
  },
  {
    path: 'membres',
    canActivate: [AuthService],
    loadChildren: () =>
      import('./ui/modules/membres/membres.module').then(
        (m) => m.MembresModule
      ),
  },
];
