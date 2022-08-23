public interface IOnResourceChange
{
	public struct Context
	{
		public Resource _resource;
		public int _value, _maxValue, _delta;
		public Context(Resource resource, int value, int maxValue, int delta)
        {
			_resource = resource;
			_value = value;
			_maxValue = maxValue;
			_delta = delta;
        }
	}
	public void OnResourceChange(Context context);
}
