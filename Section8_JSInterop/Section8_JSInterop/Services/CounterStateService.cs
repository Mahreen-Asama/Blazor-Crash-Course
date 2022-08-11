namespace Section8_JSInterop.Services
{
    public class CounterStateService
    {
        private int count;
        public event Action OnChange;       //event handle of on change
        public int CounterCount
        {
            get { return count; }
            set
            {
                count = value;
                NotifyChange();             //notify change whenever counter value set new
            }
        }

        private void NotifyChange() => OnChange?.Invoke();      //'?' to handle null things

    }
}
