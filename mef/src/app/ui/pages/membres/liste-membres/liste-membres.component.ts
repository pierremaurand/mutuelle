import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-liste-membres',
  imports: [CommonModule, RouterLink],
  templateUrl: './liste-membres.component.html',
  styleUrl: './liste-membres.component.scss',
})
export default class ListeMembresComponent {}
