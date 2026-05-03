import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Cobblemon } from './services/cobblemon';
import {MatTableModule} from '@angular/material/table';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MatTableModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('CobbleCompendium.Client');

  cobblemons = signal<any[]>([]);
  dataSource = signal<CobblemonElement[]>([]);
  cobblemonService = inject(Cobblemon);

  displayedColumns: string[] = ['pokedexNumber', 'name', 'primaryType', 'secondaryType'];

  constructor() {
    this.cobblemonService.get().subscribe(cobblemons => {
      this.cobblemons.set(cobblemons);
      this.dataSource.set(cobblemons.map((c: any) => ({
        pokedexNumber: c.pokedexNumber,
        name: c.name,
        primaryType: c.primaryType,
        secondaryType: c.secondaryType
      })));
    });
  }
}

export interface CobblemonElement {
  pokedexNumber: number;
  name: string;
  primaryType: number;
  secondaryType: number;
}
