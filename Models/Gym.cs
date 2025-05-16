namespace lab2_gym.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Subscription> Subscriptions { get; set; }
    }
}
