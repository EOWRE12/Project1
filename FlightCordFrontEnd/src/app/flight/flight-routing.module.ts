import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { DetailsComponent } from './details/details.component';

const routes: Routes = [
  { path: 'flight', redirectTo: 'flight/index', pathMatch: 'full' },
  { path: 'flight/index', component: IndexComponent },
  { path: 'flight/create', component: CreateComponent },
  { path: 'flight/edit', component: EditComponent},
  { path: 'flight/details', component: DetailsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class FlightRoutingModule { }
