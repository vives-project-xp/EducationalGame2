// using Godot;
// using System;
// using System.Collections.Generic;

// public class Spring 
// {
// 	public float velocity { get; set; } = 0;
//     private float force = 0;
//     public float height { get; private set; }
//     private float targetHeight;
// 	private void WaterUpdate(float springConstant, float dampening)
//     {
//         height = Position.Y;
//         float x = height - targetHeight;
//         float loss = -dampening * velocity;
//         force = -springConstant * x + loss;
//         velocity += force;

//         Position = new Vector2(Position.X, Position.Y + velocity);
//     }
// }

// public partial class water_body : Node2D
// {
//     [Export] private float k = 0.015f;
//     [Export] private float d = 0.03f;
//     [Export] private float spread = 0.0002f;

//     private List<Spring> springs = new List<Spring>();
//     private int passes = 8;

//     public override void _Ready()
//     {

//         foreach (Node i in GetChildren())
//         {
//             if (i is Spring spring)
//             {
//                 springs.Add(spring);
//                 spring.Initialize();

//                 Splash(2, 5);
//             }
//         }
//     }

//     public override void _PhysicsProcess(double delta)
//     {
//         foreach (Spring i in springs)
//         {
//             i.WaterUpdate(k, d);
//         }

//         List<float> leftDeltas = new List<float>(springs.Count);
//         List<float> rightDeltas = new List<float>(springs.Count);

//         for (int i = 0; i < springs.Count; i++)
//         {
//             leftDeltas.Add(0);
//             rightDeltas.Add(0);
//         }

//         for (int j = 0; j < passes; j++)
//         {
//             for (int i = 0; i < springs.Count; i++)
//             {
//                 if (i > 0)
//                 {
//                     leftDeltas[i] = spread * (springs[i].Height - springs[i - 1].Height);
//                     springs[i - 1].Velocity += leftDeltas[i];
//                 }

//                 if (i < springs.Count - 1)
//                 {
//                     rightDeltas[i] = spread * (springs[i].Height - springs[i + 1].Height);
//                     springs[i + 1].Velocity += rightDeltas[i];
//                 }
//             }
//         }
//     }

//     private void Splash(int index, float speed)
//     {
//         if (index > 0 && index < springs.Count)
//         {
//             springs[index].Velocity = speed;
//         }
//     }
// }
