using UnityEngine;
using UnityEngine.EventSystems;

public class ImageZoom : MonoBehaviour, IScrollHandler, IBeginDragHandler, IDragHandler, IPointerClickHandler
{
	private Vector3 _initialScale;

	[SerializeField]
	private float zoomSpeed = 0.1f;

	[SerializeField]
	private float maxZoom = 10f;

	public GameObject OriginalImage;
	public GameObject ChangedImage;

	public BoxCollider2D OriginalCollider;

	public BoxCollider2D ChangedCollider;
	public GameObject WrongObject;

	private Vector3 _startDragPosition;
	private Vector2 _startDragHitPosition;

	private bool _dragging = false;
	private bool _zooming = false;

	private Vector2 _initialSize;
	private float? _prevDistance;

	public void OnScroll(PointerEventData eventData)
	{
		var delta = Vector3.one * (eventData.scrollDelta.y * zoomSpeed);
		Zoom(delta);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (Input.touchCount > 1)
		{
			return;
		}

		RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(eventData.position));
		if (hit.collider != null)
		{
			var hitPosition = Vector3.Scale(hit.point, OriginalCollider.transform.localScale);
			_startDragHitPosition = hitPosition;
			_startDragPosition = OriginalImage.transform.localPosition;
		}

		_dragging = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (Input.touchCount > 1 || _zooming)
		{
			return;
		}

		Vector3 currentSize = GetCurrentSize();
		RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(eventData.position));
		if (hit.collider != null)
		{
			var hitPosition = Vector3.Scale(hit.point, OriginalCollider.transform.localScale);
			float maxX = (currentSize.x - _initialSize.x) / 2;
			float maxY = (currentSize.y - _initialSize.y) / 2;
			float deltaX = (hitPosition.x - _startDragHitPosition.x) / 2;
			float deltaY = (hitPosition.y - _startDragHitPosition.y) / 2;
			Vector3 newPosition = new Vector3(
				_startDragPosition.x + deltaX,
				_startDragPosition.y + deltaY,
				OriginalImage.transform.localPosition.z);
			newPosition.x = newPosition.x > 0
				? Mathf.Min(maxX, newPosition.x)
				: Mathf.Max(-maxX, newPosition.x);
			newPosition.y = newPosition.y > 0
				? Mathf.Min(maxY, newPosition.y)
				: Mathf.Max(-maxY, newPosition.y);
			OriginalImage.transform.localPosition = newPosition;
			ChangedImage.transform.localPosition = newPosition;
			_dragging = true;
		}
	}

	private Vector3 ClampDesiredScale(Vector3 desiredScale)
	{
		desiredScale = Vector3.Max(_initialScale, desiredScale);
		desiredScale = Vector3.Min(_initialScale * maxZoom, desiredScale);
		return desiredScale;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (Input.touchCount > 1|| _zooming || _dragging || Game.GameCompleted())
		{
			_dragging = false;
			return;
		}

		Vector3 clickPosition = eventData.position;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(clickPosition);
		Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

		RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
		if (hit.collider != null)
		{
			if (hit.collider == OriginalCollider || hit.collider == ChangedCollider)
			{
				WrongObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
				var animator = WrongObject.GetComponent<Animator>();
				animator.SetTrigger("Missed");
				var audioSource = WrongObject.GetComponent<AudioSource>();
				audioSource.Play();
			}
			else
			{
				var difference = hit.collider.GetComponent<Difference>();
				if (difference != null)
				{
					difference.SelectDifference();
				}
			}
		}

	}

	private void Start()
	{
		_initialSize = GetCurrentSize();
	}

	private void Awake()
	{
		_initialScale = OriginalImage.transform.localScale;
	}

	private Vector3 GetCurrentSize()
	{
		var sr = OriginalImage.GetComponent<SpriteRenderer>();
		Vector3 spriteSize = sr.sprite.bounds.size;
		Vector3 localScale = OriginalImage.transform.localScale;
		return Vector3.Scale(spriteSize, localScale);
	}

	private void Update()
	{
		if (Input.touchCount == 2)
		{
			_zooming = true;
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			if (_prevDistance != null)
			{
				_dragging = true;
				var newDistance = (touchOne.position - touchZero.position).magnitude;
				var delta = Vector3.one * (((newDistance - _prevDistance) * zoomSpeed) / 20);
				if (delta != null)
				{
					Zoom(delta.Value);
				}
			}

			_prevDistance = (touchOne.position - touchZero.position).magnitude;

		}
		else if( Input.touchCount == 0)
		{
			_zooming = false;
		}
		else
		{
			_prevDistance = null;
		}
	}

	private void Zoom(Vector3 delta)
	{
		delta.z = 0;
		var desiredScale = OriginalImage.transform.localScale + delta;

		desiredScale = ClampDesiredScale(desiredScale);

		OriginalImage.transform.localScale = desiredScale;
		ChangedImage.transform.localScale = desiredScale;
		Vector3 currentSize = GetCurrentSize();
		float maxX = (currentSize.x - _initialSize.x) / 2;
		float maxY = (currentSize.y - _initialSize.y) / 2;
		Vector3 newPosition = OriginalImage.transform.localPosition;
		newPosition.x = newPosition.x > 0
			? Mathf.Min(maxX, newPosition.x)
			: Mathf.Max(-maxX, newPosition.x);
		newPosition.y = newPosition.y > 0
			? Mathf.Min(maxY, newPosition.y)
			: Mathf.Max(-maxY, newPosition.y);
		OriginalImage.transform.localPosition = newPosition;
		ChangedImage.transform.localPosition = newPosition;
	}
}
