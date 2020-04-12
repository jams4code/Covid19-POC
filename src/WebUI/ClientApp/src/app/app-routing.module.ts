import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { HomeComponent } from "./home/home.component";
import { LivefeedComponent } from "./livefeed/livefeed.component";


const routes: Routes = [

  { path: 'home', component: HomeComponent, pathMatch: 'full' },
  { path: 'live', component: LivefeedComponent},
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  {
    path: "**",
    redirectTo: "/home"
  }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    RouterModule.forRoot(routes, {
      useHash: true
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
