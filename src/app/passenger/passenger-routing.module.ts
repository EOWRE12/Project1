import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [
  { path: 'passenger', redirectTo: 'passenger/index', pathMatch: 'full' },
  { path: 'passenger/index', component: IndexComponent },
  { path: 'passenger/create', component: CreateComponent },
  { path: 'passenger/edit', component: EditComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PassengerRoutingModule { }
