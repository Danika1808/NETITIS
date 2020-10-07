module Fractal
open System.Drawing
open System.Windows.Forms
open System.Numerics
open System
let temp c f size k = f - (size / 2.0) + (float c) * size / k 

let p x y = sqrt(Math.Pow(x-0.25,2.0) + Math.Pow(y,2.0))

let q x y = Math.Atan2(y, x- 0.25)

let pc q = 0.5-0.5*cos q

let createImage sizeArea heigth wight hx hy =
    let image = new Bitmap((int heigth), (int wight))
    for x in 0..image.Width-1 do
        for y in 0..image.Height-1 do
            let mutable x_ = temp x hx sizeArea wight
            let mutable y_ = temp y hy sizeArea heigth
            let mutable z = new Complex(0.0, 0.0)
            let mutable it = 0
            let mutable Break = false
            while (Break = false && it < 100) do
                it <- it + 1
                z <- z*z
                z <- z + new Complex(x_, y_)
                if (z.Magnitude > 2.0) then Break <- true 
                else 
                    image.SetPixel(x, y, Color.FromArgb(255, it % 8 * 16, it % 4 * 32, it % 2 * 64))
    image



            

