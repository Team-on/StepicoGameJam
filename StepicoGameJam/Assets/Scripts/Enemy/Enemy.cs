using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public Action<Enemy> onDie;

	[Header("Refs"), Space]
	[SerializeField] ProjectileWeapon projectileWeapon;

#if UNITY_EDITOR
	private void OnValidate() {
		if (!projectileWeapon)
			projectileWeapon = GetComponentInChildren<ProjectileWeapon>();
	}
#endif

	void Start() {
		projectileWeapon.StartAttackSequence();
	}

	void OnDestroy() {
		onDie?.Invoke(this);
	}
}
